import LoginForm from "../components/LoginForm";

const Index = () => {
  return (
    <div className=" text-white min-h-screen w-full flex justify-center items-center">
      <div className="w-[500px] h-[500px] bg-green-400 rounded-3xl border-pink-600 border-4 flex justify-center items-center">
        <LoginForm />
      </div>
    </div>
  );
};

export default Index;
