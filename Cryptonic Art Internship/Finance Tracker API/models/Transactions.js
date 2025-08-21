const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const transactionSchema = new mongoose.Schema({
  user: { 
    type: mongoose.Schema.Types.ObjectId, 
    ref: 'User',
    required: true 
    },

  type: { 
    type: String, 
    enum: ['income', 'expense'], 
    required: true 
    },

  amount: { 
    type: Number, 
    required: true 
    },

  category: { 
    type: String, 
    required: true 
    },

  date: { 
    type: Date, 
    default: Date.now 
    },
    
  note: String
});

module.exports = mongoose.model('Transaction', transactionSchema);