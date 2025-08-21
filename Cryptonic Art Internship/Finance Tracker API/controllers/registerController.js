const User = require('../models/User');
const bcrypt = require('bcrypt');
const registerDTO = require('../DTOs/registerDTO');

const addNewUser = async (req, res) => {
    const { error, value } = registerDTO.validate(req.body);
    if (error) return res.status(400).json({ message: error.details[0].message });

    const { email, password } = value;
    
    const duplicate = await User.findOne({email: email}).exec();
    if(duplicate) {
        return res.sendStatus(409).json({ message: 'email already exists.' });
    }
    try{
        const hashedPWD = await bcrypt.hash(password, 10);
        const result = await User.create( {
            'email': email,
            'password': hashedPWD
        });

        res.sendStatus(201)
        // .json({'success' : 'User created successfully'});
    }
    catch(err) {
        console.error(err);
        return res.sendStatus(500)
        // .json({ 'message': err.message });
    }}

    module.exports = {addNewUser}