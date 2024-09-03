import { postAsync } from "./http-client.api";

const baseUrl = `${process.env.REACT_APP_API_ENDPOINT}`;

function Login (model, type) {
    const url = `${baseUrl}/api/login/${type}`;
    return postAsync(url, model, false, false, true);
}

export const AuthApi ={
    Login
}