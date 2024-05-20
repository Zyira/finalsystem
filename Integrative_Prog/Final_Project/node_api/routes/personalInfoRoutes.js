const express = require('express');
const router = express.Router();
const personalInfoController = require('../controllers/personalInfoController');

router.get('/personal-info', personalInfoController.getAllPersonalInfo);
router.post('/personal-info', personalInfoController.addPersonalInfo);
router.put('/personal-info/:personalId', personalInfoController.updatePersonalInfo);
router.delete('/personal-info/:personalId', personalInfoController.deletePersonalInfo);

module.exports = router;
