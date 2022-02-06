var ws = new WebSocket('ws://localhost:8080'); // change this address to your server, if different!
ws.onopen = function(o){ console.log('open', o) };
ws.onclose = function(c){ console.log('close', c) };
ws.onmessage = function(m){ console.log('message', m.data) };
ws.onerror = function(e){ console.log('error', e) };