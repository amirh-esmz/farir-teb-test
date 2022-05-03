import axios, { AxiosResponse, Method } from 'axios'

function format(str: string, obj: object): string {
    if (obj)
        Object.keys(obj)
            .forEach(key => {
                str = str.replace(new RegExp("\\{" + key + "\\}", "gi"), obj[key as keyof object]);
            });

    return str;
};

export default class RequestBuilder {

    constructor(method?: Method, baseUrl?: string, url?: string) {
        
        this.queryParams = [];
        this.headers = [];

        if (method)
            this.method = method;

        if (baseUrl)
            this.baseUrl = baseUrl;

        if (url)
            this.url = url;
    }

    private baseUrl: string = "";
    private url: string = "";

    private queryParams: IKeyValue[] = [];
    private headers: IKeyValue[] = [];
    private defualtHeader = <any>{};

    private body: any;
    private method: Method = 'GET';

    addQueryParam(key: string, value: any): RequestBuilder {
        var stringValue = value.toString();
        this.queryParams?.push({ key, value : stringValue });
        return this;
    }

    addHeader(key: string, value: string): RequestBuilder {
        this.headers?.push({ key, value });
        return this;
    }

    setBaseUrl(url: string, args: {} = {}): RequestBuilder {
        this.baseUrl = format(url, args);
        return this;
    }

    setUrl(url: string, args: {} = {}): RequestBuilder {
        this.url = format(url, args);
        return this;
    }

    setBody(body: {}): RequestBuilder {
        this.body = body;
        return this;
    }

    setMothod(method: Method) :RequestBuilder {
        this.method = method;
        return this;
    }

    SetHeader(header : any) : RequestBuilder{
        this.defualtHeader = header;
        return this;
    }

    async GetResultAsync<T>(): Promise<T> {
        return (await this.ExcuteAsync()).data as T;
    }

    async ExcuteAsync<T>(): Promise<AxiosResponse<T>> {
        let url = new URL(this.url, this.baseUrl).toString();

        if (this.queryParams?.length) {
            url += '?';

            this.queryParams.forEach(item => {
                url+=`${encodeURI(item.key)}=${encodeURI(item.value)}&`;
            });
        }

        this.headers.forEach(item => {
            this.defualtHeader[item.key] = item.value;
        });

        let result = await axios({
            method: this.method,
            headers: this.defualtHeader,
            url: url,
            data : this.body
        });

        return result;
    }
}

export interface IKeyValue {
    key: string;
    value: string;
}