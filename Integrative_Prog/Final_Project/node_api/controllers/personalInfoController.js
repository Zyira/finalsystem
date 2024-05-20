const personalInfoModel = require("../models/personalInfo");

const getAllPersonalInfo = async (req, res) => {
  try {
    const personalInfo = await personalInfoModel.getAllPersonalInfo();
    res.json(personalInfo);
  } catch (error) {
    console.error("Error in getAllPersonalInfo:", error);
    res.status(500).json({ error: "Internal Server Error" });
  }
};

const addPersonalInfo = async (req, res) => {
  try {
    const result = await personalInfoModel.addPersonalInfo(req.body);
    res.status(201).json({ message: "Personal info added successfully", personalId: result });
  } catch (error) {
    console.error("Error in addPersonalInfo:", error);
    res.status(500).json({ error: "Internal Server Error" });
  }
};

const updatePersonalInfo = async (req, res) => {
  const { personalId } = req.params;
  try {
    const result = await personalInfoModel.updatePersonalInfo(personalId, req.body);
    res.status(200).json({ message: "Personal info updated successfully", result });
  } catch (error) {
    console.error("Error in updatePersonalInfo:", error);
    res.status(500).json({ error: "Internal Server Error" });
  }
};

const deletePersonalInfo = async (req, res) => {
  try {
    const result = await personalInfoModel.deletePersonalInfo(req.params.personalId);
    res.status(200).json({ message: "Personal info deleted successfully", result });
  } catch (error) {
    console.error("Error in deletePersonalInfo:", error);
    res.status(500).json({ error: "Internal Server Error" });
  }
};

module.exports = {
  getAllPersonalInfo,
  addPersonalInfo,
  updatePersonalInfo,
  deletePersonalInfo
};
