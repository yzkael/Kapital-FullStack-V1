import { LoginRequest } from "@/types/loginRequest";
import { LoginResponse } from "@/types/loginResponse";
import axios from 'axios';


const url = import.meta.env.VITE_API_BASE_URL as string;


export const loginRequest= async (data: LoginRequest):Promise<LoginResponse>=>{
    const response = await axios.post(`${url}/api/auth/login`,data);
    if (response.status != 200) {
        throw new Error("Something went wrong while trying to log in");
    }
    return response.data;
}