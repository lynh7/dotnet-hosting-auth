import { atom } from "recoil";
import { KEY_CONSTANT } from "../constants/key.constants";

const AuthState = atom({
  key: KEY_CONSTANT.AUTH_STATE_RECOIL,
  default: false,
});

export const MainState = { AuthState };
