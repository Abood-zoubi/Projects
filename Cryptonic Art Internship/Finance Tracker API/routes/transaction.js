const express = require('express');
const router = express.Router();
const verifyJWT = require('../middleware/verifyJWT');
const transactionController = require('../controllers/transactionController');

/**
 * @swagger
 * /transactions:
 *   get:
 *     summary: Get all transactions
 *     tags:
 *       - Transactions
 *     responses:
 *       200:
 *         description: List of transactions
 *   post:
 *     summary: Add a new transaction
 *     tags:
 *       - Transactions
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             type: object
 *             properties:
 *               amount:
 *                 type: number
 *               category:
 *                 type: string
 *               date:
 *                 type: string
 *                 format: date
 *     responses:
 *       201:
 *         description: Transaction created
 */

router.use(verifyJWT);

router
    .route('/')
    .get(transactionController.getAllTransactions)  
    .post(transactionController.createTransaction);

router
    .route('/:id')
    .get(transactionController.getTransaction)
    .put(transactionController.updateTransaction)
    .delete(transactionController.deleteTransaction);

module.exports = router;