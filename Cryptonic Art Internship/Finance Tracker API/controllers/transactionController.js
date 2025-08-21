const Transaction = require("../models/Transactions");
const { transactionDTO, getAllTransactionsDTO } = require('../DTOs/transactionDTO')

const getAllTransactions = async (req, res) => {
    const { error, value } = getAllTransactionsDTO.validate(req.query);
    if (error) return res.status(400).json({ message: error.details[0].message });

    const { type } = value;

     try {
        const filter = {
            ...(type ? { type } : {})
        };
    const transactions = await Transaction.find(filter)
    .populate("user", "email").exec();
    if (!transactions.length) return res.status(204).json({ "message": "No transaction found" });
    res.json(transactions);
        }
    catch (err) {
        res.status(500).json({ message: err.message });
    }
};

const createTransaction = async (req, res) => {
    const { error, value } = transactionDTO.validate(req.body);
    if (error) return res.status(400).json({ message: error.details[0].message });

    const { type, amount, category, date, note } = value;

    const transactionDate = date ? new Date(date) : new Date();
    try {
        const newTransaction = await Transaction.create({
            user: req.user._id,
            type,
            amount,
            category,
            date: transactionDate,
            note
        });

        res.status(201).json(newTransaction);
    } catch (err) {
        res.status(500).json({ message: err.message });
    }
};

const updateTransaction = async (req, res) => {
    const { error, value } = transactionDTO.validate(req.body);
    console.log('Validation result:', { error, value, body: req.body });
    if (error) return res.status(400).json({ message: error.details[0].message });

    const { type, amount, category, date, note } = value;
    
    const id = req.params.id;
    try {
        const transaction = await Transaction.findOne({_id: id});
        if (!transaction) return res.status(404).json({ message: "Transaction not found." });
            
        transaction.type = type;
        transaction.amount = amount;
        
        transaction.category = category;
        if (note) transaction.note = note;
        if (date) {
            const newDate = new Date(date);
            transaction.date = newDate;
        }
        const updated = await transaction.save();
        res.json(updated);
    }
    catch(err) {
        res.status(500).json({ message: err.message });
    }
};

const deleteTransaction = async (req, res) => {
    const id = req.params.id;
    if (!id) return res.status(400).json({ "message": "Transaction ID required" });
    try {
        const transaction = await Transaction.findOne({ _id: id, user: req.user._id }).exec();
        if (!transaction) {
            return res.status(204).json({ "message": `Transaction ID ${id} not found` });
        }
        const result = await transaction.deleteOne();
        res.json(result);
    } 
    catch(err) {
        res.status(500).json({ message: err.message });
    }  
};

const getTransaction = async (req, res) => {
    if (!req?.params?.id) return res.status(400).json({ "message": "Transaction ID required" });
    const transaction = await Transaction.findOne({ _id: req.params.id }).exec();
    if (!transaction) {
        return res.status(204).json({ "message": `Transaction ID ${req.params.id} not found` });
    }
    res.json(transaction);
};

module.exports = {
    getAllTransactions,
    deleteTransaction,
    getTransaction,
    createTransaction,
    updateTransaction
}