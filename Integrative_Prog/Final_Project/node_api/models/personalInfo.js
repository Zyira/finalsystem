const pool = require('../services/db');

const getAllPersonalInfo = () => {
  return new Promise((resolve, reject) => {
    pool.query("SELECT * FROM personal_info", (err, results) => {
      if (err) {
        console.error("Error fetching personal info", err);
        reject(err);
      } else {
        resolve(results);
      }
    });
  });
};

const addPersonalInfo = (info) => {
  const { firstname, lastname, middlename, age, sex, campus, department, course, major, status, year } = info;
  return new Promise((resolve, reject) => {
    const insertQuery = 'INSERT INTO personal_info (firstname, lastname, middlename, age, sex, campus, department, course, major, status, year) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)';
    pool.query(insertQuery, [firstname, lastname, middlename, age, sex, campus, department, course, major, status, year], (err, results) => {
      if (err) {
        console.error("Error adding personal info:", err);
        reject(err);
      } else {
        resolve(results.insertId);
      }
    });
  });
};

const updatePersonalInfo = (personalId, info) => {
  const { firstname, lastname, middlename, age, sex, campus, department, course, major, status, year } = info;
  return new Promise((resolve, reject) => {
    const updateQuery = 'UPDATE personal_info SET firstname = ?, lastname = ?, middlename = ?, age = ?, sex = ?, campus = ?, department = ?, course = ?, major = ?, status = ?, year = ? WHERE personal_id = ?';
    pool.query(updateQuery, [firstname, lastname, middlename, age, sex, campus, department, course, major, status, year, personalId], (err, results) => {
      if (err) {
        console.error("Error updating personal info:", err);
        reject(err);
      } else {
        resolve(results);
      }
    });
  });
};

const deletePersonalInfo = (personalId) => {
  return new Promise((resolve, reject) => {
    const deleteQuery = 'DELETE FROM personal_info WHERE personal_id = ?';
    pool.query(deleteQuery, [personalId], (err, results) => {
      if (err) {
        console.error("Error deleting personal info:", err);
        reject(err);
      } else {
        resolve(results);
      }
    });
  });
};

module.exports = {
  getAllPersonalInfo,
  addPersonalInfo,
  updatePersonalInfo,
  deletePersonalInfo
};
