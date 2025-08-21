require('dotenv').config();
const express = require('express');
const mongoose = require('mongoose');
const dotenv = require('dotenv');
const cors = require('cors');
const rateLimit = require('express-rate-limit');
const corsOptions = require('./config/corsOptions');
const cookieParser = require('cookie-parser');
const verifyJWT = require('./middleware/verifyJWT');
const path = require('path');
const bcrypt = require('bcrypt');
const credentials = require('./middleware/credentials');
const apiLimiter = require('./middleware/apiLimiter');
const connectDB = require('./config/dbConn');
const { swaggerUi, specs } = require('./config/swaggerConfig');
const PORT = process.env.PORT || 3500;
const app = express();

connectDB()

app.use(credentials);

app.use(cors(corsOptions));
app.use(express.urlencoded({extended: false}));
app.use(express.json());

app.use(cookieParser());

app.use('/', express.static(path.join(__dirname, '/public')));

app.use('/', require('./routes/root'));
app.use('/users', require('./routes/api/users'));
app.use('/register', require('./routes/register'));
app.use('/login', require('./routes/login'));
app.use('/refresh', require('./routes/refresh'));
app.use('/logout', require('./routes/logout'));
app.use('/transactions', verifyJWT, require('./routes/transaction'));
app.use('/categories', verifyJWT, require('./routes/category'));
app.use('/reports', verifyJWT, require('./routes/report'));

app.use('/api-docs', swaggerUi.serve, swaggerUi.setup(specs));
app.use('/api/users', require('./routes/api/users'));

app.all(/^.*$/, (req, res) => {
    res.status(404);
    if (req.accepts('html')) {
        res.sendFile(path.join(__dirname, 'views', '404.html'));
    } else if (req.accepts('json')) {
        res.json({ "error": "404 Not Found" });
    } else {
        res.type('txt').send("404 Not Found");
    }
});

mongoose.connection.once('open', () => {
    console.log('\nConnected to MongoDb');
    console.log("Server Running on port " + PORT);
    app.listen(PORT, () => console.log(`Server listening on port ${PORT}`));
});