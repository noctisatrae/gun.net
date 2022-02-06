const Gun = require("gun");
require("gun/axe");

const gun = Gun({peers:["http://127.0.0.1"]})

gun.get("Hey").put({hello:"hello world"})