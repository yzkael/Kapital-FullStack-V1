import { create } from 'zustand';
//Example of ussage


// Define User Type
type User = {
  id: number;
  name: string;
  email: string;
};

// Zustand Store for Local State
type UserStore = {
  selectedUser: User | null;
  setSelectedUser: (user: User | null) => void;
};

export const useUserStore = create<UserStore>((set) => ({
  selectedUser: null, //Initial Value
  setSelectedUser: (user) => set({ selectedUser: user }), 
}));
