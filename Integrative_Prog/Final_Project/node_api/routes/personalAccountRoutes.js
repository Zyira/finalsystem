const express = require('express');
const router = express.Router();
const personalAccountController = require('../controllers/personalAccountController');

router.post('/personal-account', personalAccountController.getPersonalAccount);

module.exports = router;
