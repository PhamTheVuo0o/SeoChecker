import { createSlice, PayloadAction } from '@reduxjs/toolkit';

interface GlobalVarState {
  isLoading: boolean;
  isAuth:boolean;
  currentUserId:string;
  currentUserEmail:string;
  currentUserName:string;
  currentUserAvatar:string;
  permissions:string[];
}

const initialState: GlobalVarState = {
  isLoading: false,
  isAuth: false,
  currentUserId:'',
  currentUserEmail:'',
  currentUserName:'',
  currentUserAvatar:'',
  permissions:[],
};

const GlobalVarSlice = createSlice({
  name: 'GlobalVar',
  initialState,
  reducers: {
    setIsLoading(state, action: PayloadAction<boolean>) {
      state.isLoading = action.payload;
    },
    setIsAuth(state, action: PayloadAction<boolean>) {
      state.isAuth = action.payload;
    },
    setCurrentUserId(state, action: PayloadAction<string>) {
      state.currentUserId = action.payload;
    },
    setCurrentUserEmail(state, action: PayloadAction<string>) {
      state.currentUserEmail = action.payload;
    },
    setCurrentUserName(state, action: PayloadAction<string>) {
      state.currentUserName = action.payload;
    },
    setCurrentUserAvatar(state, action: PayloadAction<string>) {
      state.currentUserAvatar = action.payload;
    },
    setPermissions(state, action: PayloadAction<string[]>) {
      state.permissions = action.payload;
    },
  },
});

export const { 
  setIsLoading,
  setIsAuth,
  setCurrentUserId,
  setCurrentUserEmail,
  setCurrentUserName,
  setCurrentUserAvatar,
  setPermissions,
} = GlobalVarSlice.actions;
export default GlobalVarSlice.reducer;
