const express = require('express');
const router = express.Router();
const controller = require('../controllers/registerController');

/**
 * @swagger
 * /register:
 *   post:
 *     summary: Register a new user
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
 *       201:
 *         description: User created
 *       400:
 *         description: Bad request
 */

router.post('/', controller.addNewUser);

module.exports = router;