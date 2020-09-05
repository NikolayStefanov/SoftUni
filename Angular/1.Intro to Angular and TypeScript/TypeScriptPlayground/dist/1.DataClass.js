"use strict";
var CustomRequest = /** @class */ (function () {
    function CustomRequest(method, uri, version, message) {
        this.fulfilled = false;
        this.method = method;
        this.uri = uri;
        this.version = version;
        this.message = message;
        this.response = undefined;
    }
    return CustomRequest;
}());
var request = new CustomRequest('GET', 'google.com', 'HTTP/1.1', '');
console.log(request);
