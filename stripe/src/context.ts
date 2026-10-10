import { createContext } from "react";
import type { SublinksType } from "./data";

export const AppContext = createContext<AppContext | undefined>(undefined);

type AppContext = {
  isSidebarOpen: boolean;
  isSubmenuOpen: boolean;
  openSidebar: () => void;
  openSubmenu: (text: string, coordinates: Coordinates) => void;
  closeSidebar: () => void;
  closeSubmenu: () => void;
  location: Coordinates | undefined;
  page: SublinksType;
};

export type Coordinates = {
  center: number;
  bottom: number;
};
