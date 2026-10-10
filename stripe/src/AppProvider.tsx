import { useState } from "react";
import { AppContext, type Coordinates } from "./context";
import sublinks from "./data";
import type { SublinksType } from "./data";

export const AppProvider = ({ children }: { children: React.ReactNode }) => {
  const [isSidebarOpen, setIsSidebarOpen] = useState(false);
  const [isSubmenuOpen, setIsSubmenuOpen] = useState(false);
  const [location, setLocation] = useState<Coordinates | undefined>(undefined);
  const [page, setPage] = useState<SublinksType>({
    page: "",
    links: [],
  });

  const openSidebar = (): void => {
    setIsSidebarOpen(true);
  };
  const closeSidebar = (): void => {
    setIsSidebarOpen(false);
  };
  const openSubmenu = (text: string, coordinates: Coordinates): void => {
    const page = sublinks.find((link) => link.page === text);
    if (page) {
      setPage(page);
      setLocation(coordinates);
      setIsSubmenuOpen(true);
    }
  };
  const closeSubmenu = (): void => {
    setIsSubmenuOpen(false);
  };

  return (
    <AppContext.Provider
      value={{
        isSidebarOpen,
        isSubmenuOpen,
        openSidebar,
        openSubmenu,
        closeSidebar,
        closeSubmenu,
        location,
        page,
      }}
    >
      {children}
    </AppContext.Provider>
  );
};
