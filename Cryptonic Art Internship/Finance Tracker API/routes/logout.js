const express = require('express');
const router = express.Router();
const controller = require('../controllers/logoutController');

/**
 * @swagger
 * /logout:
 *   post:
 *     summary: Log out a user
 *     tags:
 *       - Authentication
 *     responses:
 *       200:
 *         description: Successfully logged out
 */

router.get('/', controller.logout);

module.exports = router;