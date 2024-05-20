const personalAccountModel = require("../models/personalAccount");

const getPersonalAccount = async (req, res) => {
  const { username, password } = req.body;
  try {
    const personalAccount = await personalAccountModel.getPersonalAccount(username, password);
    if (personalAccount.length > 0) {
      res.json(personalAccount[0]);
    } else {
      res.status(404).json({ error: "Account not found" });
    }
  } catch (error) {
    console.error("Error in getPersonalAccount:", error);
    res.status(500).json({ error: "Internal Server Error" });
  }
};

module.exports = {
  getPersonalAccount,
};
