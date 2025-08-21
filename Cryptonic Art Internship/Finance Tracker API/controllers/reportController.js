const Transaction = require('../models/Transactions');
const mongoose = require('mongoose');

const getSummaryReport = async (req, res) => {
    try {
        let userId = req.user._id;
        if (typeof userId === 'string') {
            userId = new mongoose.Types.ObjectId(userId);
        }
        const income = await Transaction.aggregate([
            { $match: { user: userId, type: 'income' } },
            { $group: { _id: null, total: { $sum: '$amount' } } }
        ]);

        const expense = await Transaction.aggregate([
            { $match: { user: userId, type: 'expense' } },
            { $group: { _id: null, total: { $sum: '$amount' } } }
        ]);

        const totalIncome = income[0]?.total;
        const totalExpense = expense[0]?.total ;
        const balance = totalIncome - totalExpense;

        res.json({
            totalIncome,
            totalExpense,
            balance
        });

    } catch (err) {
        res.status(500).json({ message: err.message });
    }
};

const getReportByCategory = async (req, res) => {
    const { type = 'income', start, end } = req.query;

    try {
        const filter = {
            user: new mongoose.Types.ObjectId(req.user._id),
            type
        };

        if (start || end) {
            filter.date = {};
            if (start) filter.date.$gte = new Date(start);
            if (end) filter.date.$lte = new Date(end);
        }

        const result = await Transaction.aggregate([
            { $match: filter },
            { $group: { _id: '$category', total: { $sum: '$amount' } } },
            { $sort: { total: -1 } }
        ]);

        res.json(result.map(r => ({ category: r._id, total: r.total })));

    } catch (err) {
        res.status(500).json({ message: err.message });
    }
};

module.exports = {
    getSummaryReport,
    getReportByCategory
};