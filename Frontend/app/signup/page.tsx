'use client';

import { useState } from 'react';
import Link from 'next/link';
import { API_URL } from '@/libs/constants';

export default function SignupPage() {
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [error, setError] = useState('');
  const [loading, setLoading] = useState(false);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError('');

    if (password !== confirmPassword) {
      setError('Passwords do not match');
      return;
    }

    setLoading(true);

    try {
      const response = await fetch(`${API_URL}/api/auth/signup`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ name, email, password }),
      });

      if (!response.ok) {
        const errorBody = await response.json().catch(() => null);
        throw new Error(errorBody?.message ?? 'Signup failed');
      }

      const data = await response.json();
      // Store token and redirect
      localStorage.setItem('token', data.token);
      window.location.href = '/';
    } catch (err) {
      setError(err instanceof Error ? err.message : 'An error occurred');
    } finally {
      setLoading(false);
    }
  };

  return (
    <main className="min-h-screen bg-slate-950 px-6 py-16 text-slate-100 flex items-center justify-center">
      <div className="w-full max-w-md">
        {/* Header */}
        <div className="mb-8">
          <Link href="/" className="inline-flex items-center gap-2 mb-6">
            <div className="w-8 h-8 rounded-lg bg-gradient-to-br from-sky-400 to-cyan-400 flex items-center justify-center text-slate-950 font-bold">
              ST
            </div>
            <span className="text-lg font-bold bg-gradient-to-r from-sky-400 to-cyan-400 bg-clip-text text-transparent">
              SetTracker
            </span>
          </Link>
          <h1 className="text-3xl font-semibold">Create account</h1>
          <p className="text-slate-400 mt-2">Join SetTracker today</p>
        </div>

        {/* Error Message */}
        {error && (
          <div className="mb-6 p-4 rounded-lg border border-rose-500/30 bg-rose-500/10 text-rose-100 text-sm">
            {error}
          </div>
        )}

        {/* Form */}
        <form onSubmit={handleSubmit} className="space-y-5 mb-6">
          {/* Name Input */}
          <div>
            <label className="block text-slate-200 text-sm font-medium mb-2">
              Full Name
            </label>
            <input
              type="text"
              value={name}
              onChange={(e) => setName(e.target.value)}
              required
              className="w-full px-4 py-3 bg-white/5 border border-white/10 rounded-lg text-slate-100 placeholder-slate-400 focus:outline-none focus:border-sky-500/50 focus:bg-white/10 transition-all"
              placeholder="John Doe"
            />
          </div>

          {/* Email Input */}
          <div>
            <label className="block text-slate-200 text-sm font-medium mb-2">
              Email
            </label>
            <input
              type="email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              required
              className="w-full px-4 py-3 bg-white/5 border border-white/10 rounded-lg text-slate-100 placeholder-slate-400 focus:outline-none focus:border-sky-500/50 focus:bg-white/10 transition-all"
              placeholder="your@email.com"
            />
          </div>

          {/* Password Input */}
          <div>
            <label className="block text-slate-200 text-sm font-medium mb-2">
              Password
            </label>
            <input
              type="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              required
              className="w-full px-4 py-3 bg-white/5 border border-white/10 rounded-lg text-slate-100 placeholder-slate-400 focus:outline-none focus:border-sky-500/50 focus:bg-white/10 transition-all"
              placeholder="••••••••"
            />
          </div>

          {/* Confirm Password Input */}
          <div>
            <label className="block text-slate-200 text-sm font-medium mb-2">
              Confirm Password
            </label>
            <input
              type="password"
              value={confirmPassword}
              onChange={(e) => setConfirmPassword(e.target.value)}
              required
              className="w-full px-4 py-3 bg-white/5 border border-white/10 rounded-lg text-slate-100 placeholder-slate-400 focus:outline-none focus:border-sky-500/50 focus:bg-white/10 transition-all"
              placeholder="••••••••"
            />
          </div>

          {/* Signup Button */}
          <button
            type="submit"
            disabled={loading}
            className="w-full py-3 px-4 bg-sky-500 hover:bg-sky-600 disabled:opacity-50 disabled:cursor-not-allowed rounded-lg text-slate-950 font-semibold transition-all mt-2"
          >
            {loading ? 'Creating account...' : 'Sign Up'}
          </button>
        </form>

        {/* Divider */}
        <div className="mb-6 flex items-center gap-3">
          <div className="flex-1 h-px bg-white/10"></div>
          <span className="text-slate-400 text-sm">or</span>
          <div className="flex-1 h-px bg-white/10"></div>
        </div>

        {/* Login Link */}
        <p className="text-center text-slate-400 text-sm">
          Already have an account?{' '}
          <Link
            href="/login"
            className="text-sky-400 hover:text-sky-300 font-semibold transition-colors"
          >
            Login
          </Link>
        </p>
      </div>
    </main>
  );
}
