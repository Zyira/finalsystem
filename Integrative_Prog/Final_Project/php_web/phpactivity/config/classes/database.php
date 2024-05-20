<?php

class Database {
    private $pdo;

    public function __construct($dsn, $db_user, $db_pw) {
        try {
            $this->pdo = new PDO($dsn, $db_user, $db_pw);
            $this->pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
        } catch (PDOException $e) {
            die("Connection failed: " . $e->getMessage());
        }
    }

    public function authenticate($username, $password, $tablename) {
        $hashedPassword = "zshdsnb" . md5($password) . "ndjsfhdsf";
        $stmt = $this->pdo->prepare("SELECT * FROM {$tablename} WHERE username = ? AND password=?");
        $stmt->execute([$username, $hashedPassword]);
        return $stmt->fetch(PDO::FETCH_ASSOC);
    }

    public function validating($column, $value, $table) {
        $stmt = $this->pdo->prepare("SELECT * FROM {$table} WHERE {$column} = :value");
        $stmt->bindParam(':value', $value); 
        $stmt->execute(); 
    
        return $stmt->fetch(PDO::FETCH_ASSOC); 
    }

    public function addData($columns, $values, $tablename) {
        $columnNames = implode(',', $columns);
        $placeholders = implode(',', array_fill(0, count($columns), '?'));
        $stmt = $this->pdo->prepare("INSERT INTO {$tablename} ({$columnNames}) VALUES ({$placeholders})");
        $stmt->execute($values);
    }

    public function getAllRecords($tablename) {
        $stmt = $this->pdo->prepare("SELECT * FROM {$tablename}");
        $stmt->execute();
        
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

}

?>
