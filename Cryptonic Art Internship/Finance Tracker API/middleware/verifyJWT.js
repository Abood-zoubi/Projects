const jwt = require('jsonwebtoken');
require('dotenv').config();

const verifyJWT = (req, res, next) => {
    const authHeader = req.headers.authorization || req.headers.Authorization;
    if(!authHeader?.startsWith('Bearer ')) res.sendStatus(401)
        // .json({"Error" : "Access Denied"});
    const token = authHeader.split(" ")[1];
    jwt.verify(
        token,
        process.env.ACCESS_TOKEN_SECRET,
        (err, decoded) => {
            if(err) return res.sendStatus(403)
                // .json({'Token': 'Invalid Token' });
            req.user = decoded.UserInfo;
            req.roles = decoded.UserInfo.roles

            next();
        }
    )
}

module.exports = verifyJWT