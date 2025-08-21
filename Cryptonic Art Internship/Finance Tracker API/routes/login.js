const express = require('express');
const router = express.Router();
const controller = require('../controllers/loginController');
const loginLimiter = require('../middleware/loginLimiter');


/**
 * @swagger
 * /login:
 *   post:
 *     summary: Log in a user
 *     description: Authenticates a user and returns access and refresh tokens.
 *     tags:
 *       - Authentication
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             type: object
 *             properties:
 *               username:
 *                 type: string
 *               password:
 *                 type: string
 *     responses:
 *       200:
 *         description: Successfully logged in
 *         content:
 *           application/json:
 *             schema:
 *               type: object
 *               properties:
 *                 accessToken:
 *                   type: string
 *                 refreshToken:
 *                   type: string
 *       401:
 *         description: Invalid credentials
 */

router.post('/', loginLimiter, controller.login);

module.exports = router;