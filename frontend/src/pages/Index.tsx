import LoginForm from "../components/LoginForm";
import { useMutation } from "@tanstack/react-query";
import LoginRequestResponse from "../types/LoginRequestResponse";
import sendLoginRequest from "../utils/loginFunctions/useLogin";
import LoginRequestType from "../types/LoginRequest";

const Index = () => {
  const { mutate } = useMutation<LoginRequestResponse, Error, LoginRequestType>(
    {
      mutationFn: sendLoginRequest,
      onError: () => alert("Algo salio mal"),
      onSuccess: () => alert("Correcto!"),
    }
  );

  const handleSubmit = (LoginformData: LoginRequestType) => {
    console.log("Poto");
    mutate(LoginformData);
  };

  return (
    <div className=" text-white min-h-screen w-full flex justify-center items-center">
      <div className="w-[500px] h-[500px] bg-green-400 rounded-3xl border-pink-600 border-4 flex justify-center items-center">
        <LoginForm onSubmit={handleSubmit} />
      </div>
    </div>
  );
};

export default Index;
