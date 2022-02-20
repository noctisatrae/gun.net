const Gun = require("gun");

const gun = Gun({peers:["http://127.0.0.1/gun"]})

gun.get("test").on(data => {
    console.log(data)
})