const pool = require('../services/db');

const getPersonalAccount = (username, password) => {
  return new Promise((resolve, reject) => {
    const selectQuery = 'SELECT * FROM personal_accounts WHERE username = ? AND password = ?';
    pool.query(selectQuery, [username, password], (err, results) => {
      if (err) {
        console.error("Error fetching personal account:", err);
        reject(err);
      } else {
        resolve(results);
      }
    });
  });
};

module.exports = {
  getPersonalAccount,
};
