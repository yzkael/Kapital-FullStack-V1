import { useUsers } from "../utils/useUsers";
import { useUserStore } from "../utils/useUserStore";

const UserList = () => {
  const { data: users, isLoading, error } = useUsers();
  const { selectedUser, setSelectedUser } = useUserStore();

  if (isLoading) return <p>Loading...</p>;
  if (error) return <p>Error loading users</p>;

  return (
    <div>
      <h2>User List</h2>
      <ul>
        {users?.map((user) => (
          <li
            key={user.id}
            style={{
              cursor: "pointer",
              fontWeight: selectedUser?.id === user.id ? "bold" : "normal",
            }}
            onClick={() => setSelectedUser(user)}
          >
            {user.name} ({user.email})
          </li>
        ))}
      </ul>

      {selectedUser && (
        <div>
          <h3>Selected User</h3>
          <p>
            {selectedUser.name} ({selectedUser.email})
          </p>
        </div>
      )}
    </div>
  );
};

export default UserList;
