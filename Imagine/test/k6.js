import http from 'k6/http';
import { sleep } from 'k6';

export default function () {
    let res = http.get('http://imaginewebsite.com.tr/'); /*, JSON.stringify({
        email: 'user' + Math.random() + "@example.com",
        name: 'user' + Math.random(),
        password: "password123",
        validatePassword: "password123"
    }), {
        headers: {
            'Content-Type': 'application/json',  // Change this to application/json
        },
});*/
    console.log(`Response status: ${res.status}`);
    console.log(`Response body: ${res.body}`);
    sleep(1);
}