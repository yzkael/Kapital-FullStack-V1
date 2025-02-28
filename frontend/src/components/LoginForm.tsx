import { useForm } from "react-hook-form";
import LoginRequestType from "../types/LoginRequest";

type LoginFormProps = {
  onSubmit: (data: LoginRequestType) => void;
};

const LoginForm = ({ onSubmit }: LoginFormProps) => {
  const {
    register,
    formState: { errors },
    handleSubmit,
  } = useForm<LoginRequestType>();

  return (
    <form
      onSubmit={handleSubmit(onSubmit)}
      className="flex h-full w-full justify-center items-center"
    >
      <div className="flex justify-center items-center h-[80%] w-[80%] bg-amber-400 flex-col gap-[55px]">
        {/* Usermane */}
        <div className="w-[80%] flex flex-col gap-2">
          <label htmlFor="username" className="font-bold text-2xl">
            Username
          </label>
          <input
            {...register("Username", {
              required: "Username is required",
              minLength: {
                value: 4,
                message: "Username must be at least 4 characters long",
              },
            })}
            type="text"
            id="username"
            placeholder="Place your username here"
            className="bg-white rounded-xl text-black/80 px-4"
          />
          {errors.Username && (
            <span className="text-sm text-red-500 font-semibold">
              {errors.Username.message}
            </span>
          )}
        </div>
        {/* Password */}
        <div className="w-[80%] flex flex-col gap-2">
          <label htmlFor="password" className="font-bold text-2xl">
            Password
          </label>
          <input
            {...register("Password", {
              required: "A password is required.",
              minLength: {
                value: 6,
                message: "The password must be 6 characters or longer.",
              },
            })}
            id="password"
            placeholder="Place your password here"
            className="bg-white rounded-xl text-black/80 px-4"
            type="password"
          />
          {errors.Password && (
            <span className="text-sm text-red-500 font-semibold">
              {errors.Password.message}
            </span>
          )}
        </div>
        {/* Button */}
        <div className="flex justify-center items-center relative w-full">
          <button className="px-2 py-1 bg-blue-400 text-lg font-bold absolute rounded-2xl hover:bg-blue-700 transition-all hover:scale-110 hover:px-5 hover:py-2 hover:rounded-full cursor-pointer">
            Poto
          </button>
        </div>
      </div>
    </form>
  );
};

export default LoginForm;
