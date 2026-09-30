'use server'

import { cookies } from 'next/headers'
import { redirect } from 'next/navigation'
import { API_URL } from '@/libs/constants'

interface AuthResponse {
    id: number
    name: string
    email: string
    token: string
}

//Function to handle user login, takes form data as input, sends a request to the API, and sets cookies on successful login
export async function login(formData: FormData) { 
    const email = formData.get('email')
    const password = formData.get('password')

    if (typeof email !== 'string' || typeof password !== 'string' || !email || !password) {
        throw new Error('Email and password are required')
    }

    const res = await fetch(`${API_URL}/api/auth/login`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ email, password }),
    })
    
    if (!res.ok) {
        const errorBody = await res.json().catch(() => null)
        throw new Error(errorBody?.message ?? 'Invalid credentials')
    }

    const { token, name, email: userEmail, id } = (await res.json()) as AuthResponse

    const cookieStore = await cookies()
    cookieStore.set('token', token, {
        httpOnly: true,
        path: '/',
    })

    cookieStore.set('email', userEmail,
    {
        httpOnly: true,
        path: '/',
    })

    cookieStore.set('name', name, { 
        httpOnly: true,
        path: '/',
    })

    cookieStore.set('userId', id.toString(), {
        httpOnly: true,
        path: '/',
    })

    redirect('/')
}
// Function to handle user logout, deletes the authentication cookies and redirects to the login page
export async function logout() {
    const cookieStore = await cookies()

    cookieStore.delete('token')
    cookieStore.delete('email')
    cookieStore.delete('name')
    cookieStore.delete('userId')
    redirect('/login')
}