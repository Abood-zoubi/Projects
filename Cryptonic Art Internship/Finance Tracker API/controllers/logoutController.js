const User = require('../models/User');

const logout = async (req, res) => {
    const cookies = req.cookies;
    if( !cookies?.jwt) return res.sendStatus(204);
    const refreshToken = cookies.jwt;
    
    const found = await User.findOne({ refreshToken }).exec();
    if(!found) {
        res.clearCookie('jwt', {httpOnly: true, maxAge: 24 * 60 * 60 * 1000})
        return res.sendStatus(204);
    }
    found.refreshToken = '';
    const result = await found.save();

    res.clearCookie('jwt', {httpOnly: true, maxAge: 24 * 60 * 60 * 1000});
    res.sendStatus(204);

}
module.exports = {logout}