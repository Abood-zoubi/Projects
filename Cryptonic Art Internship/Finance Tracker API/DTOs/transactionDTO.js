const joi = require('joi');

const transactionDTO = joi.object({
    type: joi.string().valid('income', 'expense').required(),
    amount: joi.number().min(1).required(),
    category: joi.string().required(),

    date: joi.date().less('now')
    .messages({
            'date.base': `"date" must be a valid date`,
            'date.less': `"date" cannot be in the future`,
            'any.required': `"date" is required`
        }).optional(),

    note: joi.string().allow('', null)
});

const getAllTransactionsDTO = joi.object({
    type: joi.string().valid('income', 'expense').optional()
}) 

module.exports = {
    transactionDTO,
    getAllTransactionsDTO
};
