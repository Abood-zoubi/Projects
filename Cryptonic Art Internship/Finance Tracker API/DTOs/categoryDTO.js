const joi = require('joi');

const CategoryDTO = joi.object({
    name: joi.string().required(),
    type: joi.string().valid('income', 'expense').required(),
    color: joi.string().pattern(/^#([0-9a-fA-F]{3}){1,2}$/).required()
});

module.exports = CategoryDTO;