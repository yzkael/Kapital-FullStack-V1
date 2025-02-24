import { useQuery } from '@tanstack/react-query';
import axios from 'axios';
//Example of usage


// Define User Type
type User = {
  id: number;
  name: string;
  email: string;
};

// Fetch Users with React Query
export const useUsers = () => {
  return useQuery({
    queryKey: ['users'], // Cache key
    queryFn: async () => {
      const { data } = await axios.get<User[]>('https://jsonplaceholder.typicode.com/users');
      return data;
    },
    staleTime: 1000 * 60 * 5, // 5 minutes cache
  });
};
