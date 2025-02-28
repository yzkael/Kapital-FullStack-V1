import axios from 'axios';
import LoginRequestType from '../../types/LoginRequest';
import LoginRequestResponse from '../../types/LoginRequestResponse';



const sendLoginRequest = async (loginModel:LoginRequestType):Promise<LoginRequestResponse>=>
         {
            try {
                const response = await axios.post<LoginRequestResponse>("http://localhost:5259/api/auth/login", loginModel, {withCredentials: true});
                localStorage.setItem("access-token",response.data.accessToken);
                return response.data; 
            } catch (error) {
                console.error(error);
                throw error; // Ensure errors are handled correctly
            }
        }
export default sendLoginRequest;