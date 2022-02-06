const Gun = require("gun");

const gun = Gun({peers:["http://127.0.0.1"]})

gun.get("Hey", (data) => {
    console.log(data);
})