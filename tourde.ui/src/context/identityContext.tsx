import React, { createContext, useState } from "react";
import { IdentityContextType } from "../types/identityContextType";


export const IdentityContext = createContext<IdentityContextType>({
  roles: [],
  setRoles: () => {}
});

const IdentityContextProvider: React.FC<{children: React.ReactNode}> = ({children }) => {
  const [roles, setRoles] = useState<string[]>([]);

  return (
    <IdentityContext.Provider
      value={{
        roles,
        setRoles
      }}
    >
      {children}
    </IdentityContext.Provider>
  )
};

export default IdentityContextProvider;
