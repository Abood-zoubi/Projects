const rateLimit = require('express-rate-limit');

const apiLimiter = rateLimit({
  windowMs: 60 * 60 * 1000, 
  max: 100, // limit each user to 100 requests per hour
  message: {
    message: 'API rate limit exceeded. Maximum 100 requests per hour allowed.'
  },
  standardHeaders: true,
  legacyHeaders: false,
  // keyGenerator: (req) => {
  //   return req.user?._id || req.ip; 
  // }
});

module.exports = apiLimiter;