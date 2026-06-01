import Link from "next/link";

export default function Home() {
  return (
    <main className="min-h-screen bg-gradient-to-br from-slate-950 via-slate-900 to-slate-950 px-4 py-16">
      {/* Background blur elements */}
      <div className="fixed inset-0 overflow-hidden pointer-events-none">
        <div className="absolute top-0 right-0 w-96 h-96 bg-sky-500/20 rounded-full blur-3xl opacity-30"></div>
        <div className="absolute bottom-0 left-0 w-96 h-96 bg-cyan-500/20 rounded-full blur-3xl opacity-30"></div>
      </div>

      <div className="relative z-10 mx-auto max-w-6xl">
        {/* Hero Section */}
        <div className="mb-20 text-center">
          <h1 className="text-5xl sm:text-6xl font-bold mb-6 bg-gradient-to-r from-sky-400 via-cyan-400 to-blue-400 bg-clip-text text-transparent">
            SetTracker
          </h1>
          <p className="text-xl text-slate-300 mb-8 max-w-2xl mx-auto">
            Track your workouts, monitor your progress, and achieve your fitness goals with precision.
          </p>
          <Link
            href="/exercises"
            className="inline-block px-8 py-4 bg-gradient-to-r from-sky-500 to-cyan-500 text-slate-950 font-semibold rounded-xl hover:from-sky-400 hover:to-cyan-400 transition-all duration-300 shadow-lg hover:shadow-sky-500/50"
          >
            Start Training
          </Link>
        </div>

        {/* Feature Cards Grid */}
        <div className="grid md:grid-cols-3 gap-6 mb-16">
          {/* Exercises Card */}
          <div className="group relative">
            <div className="absolute inset-0 bg-gradient-to-r from-sky-500 to-cyan-500 rounded-2xl opacity-0 group-hover:opacity-20 blur-xl transition-all duration-300"></div>
            <Link href="/exercises">
              <div className="relative h-64 rounded-2xl backdrop-blur-xl bg-white/5 border border-white/10 hover:border-white/20 p-8 flex flex-col justify-between transition-all duration-300 hover:bg-white/10 cursor-pointer">
                <div>
                  <div className="w-12 h-12 rounded-lg bg-sky-500/20 flex items-center justify-center mb-4">
                    <span className="text-2xl">💪</span>
                  </div>
                  <h2 className="text-2xl font-bold text-white mb-2">Exercises</h2>
                  <p className="text-slate-400">Browse and explore our extensive exercise library</p>
                </div>
                <div className="text-sky-400 font-semibold flex items-center gap-2">
                  Explore <span>→</span>
                </div>
              </div>
            </Link>
          </div>

          {/* Progress Card */}
          <div className="group relative">
            <div className="absolute inset-0 bg-gradient-to-r from-cyan-500 to-blue-500 rounded-2xl opacity-0 group-hover:opacity-20 blur-xl transition-all duration-300"></div>
            <div className="relative h-64 rounded-2xl backdrop-blur-xl bg-white/5 border border-white/10 hover:border-white/20 p-8 flex flex-col justify-between transition-all duration-300 hover:bg-white/10">
              <div>
                <div className="w-12 h-12 rounded-lg bg-cyan-500/20 flex items-center justify-center mb-4">
                  <span className="text-2xl">📊</span>
                </div>
                <h2 className="text-2xl font-bold text-white mb-2">Track Progress</h2>
                <p className="text-slate-400">Monitor your personal records and improvements</p>
              </div>
              <div className="text-cyan-400 font-semibold flex items-center gap-2">
                View Stats <span>→</span>
              </div>
            </div>
          </div>

          {/* Workout Card */}
          <div className="group relative">
            <div className="absolute inset-0 bg-gradient-to-r from-blue-500 to-indigo-500 rounded-2xl opacity-0 group-hover:opacity-20 blur-xl transition-all duration-300"></div>
            <div className="relative h-64 rounded-2xl backdrop-blur-xl bg-white/5 border border-white/10 hover:border-white/20 p-8 flex flex-col justify-between transition-all duration-300 hover:bg-white/10">
              <div>
                <div className="w-12 h-12 rounded-lg bg-blue-500/20 flex items-center justify-center mb-4">
                  <span className="text-2xl">🎯</span>
                </div>
                <h2 className="text-2xl font-bold text-white mb-2">Workout Plans</h2>
                <p className="text-slate-400">Create and follow personalized training routines</p>
              </div>
              <div className="text-blue-400 font-semibold flex items-center gap-2">
                Plan Workout <span>→</span>
              </div>
            </div>
          </div>
        </div>

        {/* Stats Section */}
        <div className="relative rounded-3xl backdrop-blur-xl bg-white/5 border border-white/10 p-12 mb-16">
          <div className="grid md:grid-cols-4 gap-8">
            <div className="text-center">
              <div className="text-4xl font-bold text-sky-400 mb-2">500+</div>
              <div className="text-slate-400">Exercises</div>
            </div>
            <div className="text-center">
              <div className="text-4xl font-bold text-cyan-400 mb-2">1M+</div>
              <div className="text-slate-400">Workouts Tracked</div>
            </div>
            <div className="text-center">
              <div className="text-4xl font-bold text-blue-400 mb-2">50K+</div>
              <div className="text-slate-400">Active Users</div>
            </div>
            <div className="text-center">
              <div className="text-4xl font-bold text-indigo-400 mb-2">100%</div>
              <div className="text-slate-400">Free to Use</div>
            </div>
          </div>
        </div>

        {/* CTA Section */}
        <div className="text-center">
          <p className="text-slate-400 mb-6">Ready to transform your fitness journey?</p>
          <div className="flex flex-col sm:flex-row gap-4 justify-center">
            <Link
              href="/exercises"
              className="px-8 py-3 bg-sky-500 hover:bg-sky-400 text-slate-950 font-semibold rounded-xl transition-all duration-300"
            >
              Get Started
            </Link>
            <button className="px-8 py-3 backdrop-blur-xl bg-white/5 border border-white/10 hover:bg-white/10 text-white font-semibold rounded-xl transition-all duration-300">
              Learn More
            </button>
          </div>
        </div>
      </div>
    </main>
  );
}
