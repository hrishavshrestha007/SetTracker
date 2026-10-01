import { login } from "@/modules/auth/actions";
import Link from "next/link";

export default function LoginPage() {
  return (
    <main className="min-h-screen bg-slate-950 px-6 py-16 text-slate-100 flex items-center justify-center">
      <div className="w-full max-w-md">
        <div className="mb-8">
          <Link href="/" className="inline-flex items-center gap-2 mb-6">
            <div className="w-8 h-8 rounded-lg bg-gradient-to-br from-sky-400 to-cyan-400 flex items-center justify-center text-slate-950 font-bold">
              ST
            </div>
            <span className="text-lg font-bold bg-gradient-to-r from-sky-400 to-cyan-400 bg-clip-text text-transparent">
              SetTracker
            </span>
          </Link>
          <h1 className="text-3xl font-semibold">Welcome back</h1>
          <p className="text-slate-400 mt-2">Login to your account</p>
        </div>

        <div className="rounded-2xl border border-white/10 bg-white/[0.04] p-6 shadow-2xl shadow-black/20 backdrop-blur-xl">
          <form action={login} className="space-y-5">
            <div>
              <label htmlFor="email" className="block text-slate-200 text-sm font-medium mb-2">
                Email
              </label>
              <input
                type="email"
                name="email"
                id="email"
                required
                className="w-full px-4 py-3 bg-white/5 border border-white/10 rounded-lg text-slate-100 placeholder-slate-400 focus:outline-none focus:border-sky-500/50 focus:bg-white/10 transition-all"
                placeholder="your@email.com"
              />
            </div>

            <div>
              <label htmlFor="password" className="block text-slate-200 text-sm font-medium mb-2">
                Password
              </label>
              <input
                type="password"
                name="password"
                id="password"
                required
                className="w-full px-4 py-3 bg-white/5 border border-white/10 rounded-lg text-slate-100 placeholder-slate-400 focus:outline-none focus:border-sky-500/50 focus:bg-white/10 transition-all"
                placeholder="Password"
              />
            </div>

            <button
              type="submit"
              className="w-full py-3 px-4 bg-sky-500 hover:bg-sky-600 rounded-lg text-slate-950 font-semibold transition-all"
            >
              Login
            </button>
          </form>
        </div>

        <p className="text-center text-slate-400 text-sm">
          Don't have an account?{" "}
          <Link
            href="/signup"
            className="text-sky-400 hover:text-sky-300 font-semibold transition-colors"
          >
            Sign up
          </Link>
        </p>
      </div>
    </main>
  );
}