const express = require('express');
const router = express.Router();
const controller = require('../controllers/refreshTokenController');

/**
 * @swagger
 * /refresh:
 *   get:
 *     summary: Refresh access token
 *     tags:
 *       - Authentication
 *     responses:
 *       200:
 *         description: Token refreshed
 *       401:
 *         description: Invalid refresh token
 */

router.get('/', controller.handleRefreshToken);

module.exports = router;