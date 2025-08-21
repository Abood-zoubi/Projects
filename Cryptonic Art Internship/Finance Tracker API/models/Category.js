const mongoose = require('mongoose');

const categorySchema = new mongoose.Schema({
  user: { 
    type: mongoose.Schema.Types.ObjectId, 
    ref: 'User', 
    required: true 
  },

  name: { 
    type: String, 
    required: true 
  },

  type: { 
    type: String, 
    enum: ['income', 'expense'], 
    required: true 
  },
  
  color: { 
    type: String // hex color for UI
  } 
});

module.exports = mongoose.model('Category', categorySchema);