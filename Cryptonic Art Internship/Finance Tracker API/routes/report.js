const express = require('express');
const router = express.Router();
const verifyJWT = require('../middleware/verifyJWT');
const reportController = require('../controllers/reportController');

/**
 * @swagger
 * /reports:
 *   get:
 *     summary: Get financial reports
 *     tags:
 *       - Reports
 *     responses:
 *       200:
 *         description: Financial report data
 */

router.use(verifyJWT);

router.get('/summary', reportController.getSummaryReport);
router.get('/by-category', reportController.getReportByCategory);

module.exports = router;