const Category = require('../models/Category');
const CategoryDTO = require('../DTOs/categoryDTO');

const getAllCategories = async (req, res) => {
    try {
        const categories = await Category.find();
        
        if (!categories || categories.length === 0) {
            return res.status(204).json({ message: 'No category found' });
        }

        return res.json(categories); 
    } catch (error) {
        return res.status(500).json({ message: error.message });
    }
};

const createCategory = async (req, res) => {
    const { error, value } = CategoryDTO.validate(req.body);
    if (error) return res.status(400).json({ message: error.details[0].message });

    const { name, type, color } = value;

    const exists = await Category.findOne({ name, user: req.user._id });
    if (exists) {
        return res.status(409)
        
        .json({ message: 'Category name already exists for this user.' });
    }
     try {
        const category = await Category.create({
            name,
            type,
            color,
            user: req.user._id
        });

        res.status(201)
        .json(category);
    } catch (err) {
        res.status(500).json({ message: err.message });
    }
};

const updateCategory = async (req, res) => {
    const { error, value } = CategoryDTO.validate(req.body);
    if (error) return res.status(400).json({ message: error.details[0].message });

    const { name, type, color } = value;
    
    const id = req.params.id;
    try {
        const category = await Category.findOne({ _id: req.params.id, user: req.user._id });
        if (!category) return res.status(404).json({ message: 'Category not found.' });
        const duplicate = await Category.findOne({ name, user: req.user._id });
        if (duplicate) return res.status(409).json({ message: 'Category name already exists.' });

        category.name = name;
        category.type = type;
        category.color = color;
        
        const updated = await category.save();
        res.json(updated);
    }
    catch(err) {
        res.status(500).json({ message: err.message });
    }
};

const deleteCategory = async (req, res) => {
    try {
        const category = await Category.findOne({ _id: req.params.id, user: req.user._id });
        if (!category) return res.status(404)
            //.json({ message: 'Category not found.' });

        const result = await category.deleteOne();
        res
        //.json(result);
    } catch (err) {
        res.status(500)
        //.json({ message: err.message });
    }
};

module.exports = {
    getAllCategories,
    createCategory,
    updateCategory,
    deleteCategory
};
