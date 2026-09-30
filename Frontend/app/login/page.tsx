import { login } from "@/modules/auth/actions";

export default function LoginPage() {
  return (
    <main className="min-h-screen bg-slate-950 px-6 py-16 text-slate-100">
      <div className="mx-auto max-w-xl">
        <h1 className="text-3xl font-semibold">Login</h1>
        <p className="mt-2 text-slate-400">Please enter your credentials to log in.</p>

        <form action={login} className="mt-6 space-y-4">
          <div>
            <label htmlFor="email" className="block text-sm font-medium text-slate-300">
              Email
            </label>
            <input
              type="email"
              name="email"
              id="email"
              required
              className="mt-1 block w-full rounded-md border border-slate-700 bg-slate-800 px-3 py-2 text-slate-100 placeholder-slate-500 focus:border-sky-500 focus:ring focus:ring-sky-500 focus:ring-opacity-50"
            />
          </div>

          <div>
            <label htmlFor="password" className="block text-sm font-medium text-slate-300">
              Password
            </label>
            <input
              type="password"
              name="password"
              id="password"
              required
              className="mt-1 block w-full rounded-md border border-slate-700 bg-slate-800 px-3 py-2 text-slate-100 placeholder-slate-500 focus:border-sky-500 focus:ring focus:ring-sky-500 focus:ring-opacity-50"
            />
          </div>

          <button
            type="submit"
            className="w-full rounded-md bg-gradient-to-r from-sky-500 to-cyan-500 px-4 py-2 text-lg font-semibold text-slate-950 hover:from-sky-400 hover:to-cyan-400 focus:outline-none focus:ring-2 focus:ring-sky-500 focus:ring-offset-2 transition-all duration-300"
          >
            Log In
          </button>
        </form>
      </div>
    </main>
  );  
}