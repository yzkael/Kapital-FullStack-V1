import { create } from "zustand";

type LoginData = {
    username: string;
    password: string;
};

type LoginDataStore = {
    data: LoginData | null; // data can be null or LoginData
    setLoginData: (loginData: LoginData | null) => void; // Accepts LoginData or null
};

export const useLoginStore = create<LoginDataStore>((set) => ({
    data: null,
    setLoginData: (data: LoginData | null) => set({ data }),
}));
