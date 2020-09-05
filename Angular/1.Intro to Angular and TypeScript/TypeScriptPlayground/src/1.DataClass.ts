class CustomRequest{
    constructor(method: string, uri:string, version:string, message:string) {
        this.method = method;
        this.uri = uri;
        this.version = version;
        this.message = message;
        this.response = undefined!;
    }
    public method: string;
    public uri : string;
    public version : string;
    public message: string;
    public response : string ;
    public fulfilled :boolean = false;
}

let request = new CustomRequest('GET', 'google.com', 'HTTP/1.1', '');
console.log(request);