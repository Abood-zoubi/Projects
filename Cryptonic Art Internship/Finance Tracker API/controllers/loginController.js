const User = require('../models/User');
const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');
const loginDTO = require('../DTOs/loginDTO');

const login = async (req, res) => {
    const { error, value } = loginDTO.validate(req.body);
    if (error) return res.status(400).json({ message: error.details[0].message });

    const { email, password } = value;

    const found = await User.findOne({email: email}).exec();
    if(!found) {
        return res.sendStatus(409).json({ message: 'User not found.' });
    }
    const match = await bcrypt.compare(password, found.password);
    
    if(match)
    {
        const roles = Object.values(found.roles);
        const accessToken = jwt.sign(
            {'UserInfo': {
                '_id': found._id,
                'email' : found.email,
                'roles' : roles
                }
            },
            process.env.ACCESS_TOKEN_SECRET,
            {expiresIn: '24h'}
        );
        const refreshToken = jwt.sign(
            {'email' : found.email},
            process.env.REFRESH_TOKEN_SECRET,
            {expiresIn: '7d'}
        );

        found.refreshToken = refreshToken;
        const result = await found.save();
        console.log(result);

        res.cookie('jwt', refreshToken, {httpOnly: true, maxAge: 24 * 60 * 60 *1000});  
        res.json({roles ,accessToken});
    }
    else
        res.sendStatus(401);
    }
    
module.exports = {login}