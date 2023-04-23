import { createSlice } from "@reduxjs/toolkit";

const initialState = {
	name: "",
	age: 0,
	email: "",
	isLogin: false,
};

const userSlice = createSlice({
	name: "user",
	initialState,
	reducers: {
		setName: (state, action) => {
			state.name = action.payload;
		},
		setAge: (state, action) => {
			state.age = action.payload;
		},
		setEmail: (state, action) => {
			state.email = action.payload;
		},
		setIsLogin: (state, action) => {
			state.isLogin = action.payload;
		},
	},
});

export const { setName, setAge, setEmail, setIsLogin } = userSlice.actions;
export default userSlice.reducer;
