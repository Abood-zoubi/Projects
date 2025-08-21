const rateLimit = require('express-rate-limit');

const loginLimiter = rateLimit({
  windowMs: 60 * 1000, // 1 minute
  max: 5,
  message: {
    message: 'Too many login attempts from this IP. Please try again after 60 seconds.'
  },
  standardHeaders: true,
  legacyHeaders: false
});

module.exports = loginLimiter;