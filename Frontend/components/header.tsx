'use client';

import Link from "next/link";
import { useState, useEffect } from "react";
import { logout } from "@/modules/auth/actions";

interface HeaderProps {
  userName?: string;
}

export default function Header({ userName }: HeaderProps) {
  const [isMenuOpen, setIsMenuOpen] = useState(false);

  return (
    <header className="fixed top-0 left-0 right-0 z-50">
      {/* Backdrop blur */}
      <div className="absolute inset-0 backdrop-blur-xl bg-slate-950/30 border-b border-white/10"></div>

      <nav className="relative mx-auto max-w-7xl px-4 py-4 flex items-center justify-between">
        {/* Logo */}
        <Link href="/" className="flex items-center gap-2">
          <div className="w-8 h-8 rounded-lg bg-gradient-to-br from-sky-400 to-cyan-400 flex items-center justify-center text-slate-950 font-bold">
            ST
          </div>
          <span className="hidden sm:inline text-lg font-bold bg-gradient-to-r from-sky-400 to-cyan-400 bg-clip-text text-transparent">
            SetTracker
          </span>
        </Link>

        {/* Auth Buttons & Mobile Menu Toggle */}
        <div className="flex items-center gap-4">
          {userName ? (
            <>
              <Link href="/user" className="hidden sm:block px-6 py-2 text-slate-300 hover:text-white font-semibold rounded-lg transition-all duration-300">
                {userName}
              </Link>
              <form action={logout} className="hidden sm:block">
                <button type="submit" className="px-6 py-2 text-slate-300 hover:text-white font-semibold rounded-lg transition-all duration-300">
                  Log out
                </button>
              </form>
            </>
          ) : (
            <>
              <Link href="/login" className="hidden sm:block px-6 py-2 text-slate-300 hover:text-white font-semibold rounded-lg transition-all duration-300">
                Login
              </Link>
              <Link href="/signup" className="hidden sm:block px-6 py-2 bg-gradient-to-r from-sky-500 to-cyan-500 hover:from-sky-400 hover:to-cyan-400 text-slate-950 font-semibold rounded-lg transition-all duration-300">
                Sign Up
              </Link>
            </>
          )}

          {/* Mobile Menu Toggle */}
          <button
            onClick={() => setIsMenuOpen(!isMenuOpen)}
            className="sm:hidden p-2 hover:bg-white/10 rounded-lg transition-colors"
          >
            <svg
              className="w-6 h-6 text-slate-300"
              fill="none"
              stroke="currentColor"
              viewBox="0 0 24 24"
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                strokeWidth={2}
                d={isMenuOpen ? "M6 18L18 6M6 6l12 12" : "M4 6h16M4 12h16M4 18h16"}
              />
            </svg>
          </button>
        </div>
      </nav>

      {/* Mobile Menu */}
      {isMenuOpen && (
        <div className="sm:hidden absolute top-full left-0 right-0 backdrop-blur-xl bg-slate-950/50 border-b border-white/10">
          <div className="max-w-7xl mx-auto px-4 py-4 flex flex-col gap-3">
            {userName ? (
              <>
                <Link href="/user" className="w-full px-6 py-2 text-slate-300 hover:text-white font-semibold rounded-lg transition-all duration-300 text-left block">
                  {userName}
                </Link>
                <form action={logout}>
                  <button type="submit" className="w-full px-6 py-2 text-slate-300 hover:text-white font-semibold rounded-lg transition-all duration-300 text-left">
                    Log out
                  </button>
                </form>
              </>
            ) : (
              <>
                <Link href="/login" className="w-full px-6 py-2 text-slate-300 hover:text-white font-semibold rounded-lg transition-all duration-300 text-left block">
                  Login
                </Link>
                <Link href="/signup" className="w-full px-6 py-2 bg-gradient-to-r from-sky-500 to-cyan-500 hover:from-sky-400 hover:to-cyan-400 text-slate-950 font-semibold rounded-lg transition-all duration-300 block text-center">
                  Sign Up
                </Link>
              </>
            )}
          </div>
        </div>
      )}
    </header>
  );
}