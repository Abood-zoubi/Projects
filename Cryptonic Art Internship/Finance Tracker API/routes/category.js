const express = require('express');
const router = express.Router();
const verifyJWT = require('../middleware/verifyJWT');
const categoryController = require('../controllers/categoryController');

/**
 * @swagger
 * /categories:
 *   get:
 *     summary: Get all categories
 *     tags:
 *       - Categories
 *     responses:
 *       200:
 *         description: List of categories
 *   post:
 *     summary: Add a new category
 *     tags:
 *       - Categories
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             type: object
 *             properties:
 *               name:
 *                 type: string
 *     responses:
 *       201:
 *         description: Category created
 */

router.use(verifyJWT);

router
    .route('/')
    .get(categoryController.getAllCategories)
    .post(categoryController.createCategory);

router
    .route('/:id')
    .put(categoryController.updateCategory)
    .delete(categoryController.deleteCategory);

module.exports = router;