const User = require('../models/User');
const jwt = require('jsonwebtoken');

const handleRefreshToken = async (req, res) => {
    const cookies = req.cookies;
    if( !cookies?.jwt) return res.sendStatus(401);
    console.log(cookies.jwt);
    const refreshToken = cookies.jwt;
    
    const found = await User.findOne({ refreshToken }).exec();
    if(!found) {
        return res.sendStatus(403);
    }
    
    jwt.verify(
        refreshToken,
        process.env.REFRESH_TOKEN_SECRET,
        (err, decoded) => {
            if(err || found.email !== decoded.email) return res.sendStatus(403);
            const roles = Object.values(found.roles);
            const accessToken = jwt.sign(
                {'UserInfo': {
                    '_id': found._id,
                    'email': decoded.email,
                    'roles': roles
                    }
                },
                process.env.ACCESS_TOKEN_SECRET,
                {expiresIn: '24h'}
            );
            res.json({roles, accessToken})
        }
    );
}
module.exports = {handleRefreshToken}